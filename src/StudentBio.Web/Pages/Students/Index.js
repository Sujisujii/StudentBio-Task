$(function () {
    var l = abp.localization.getResource('StudentBio');
    var createModal = new abp.ModalManager(abp.appPath + 'Students/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Students/EditModal');

    var dataTable = $('#StudentsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(studentBio.students.student.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('StudentBio.Students.Edit'), 
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('StudentBio.Students.Delete'),

                                    confirmMessage: function (data) {
                                        return l('StudentDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        studentBio.students.student
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }

                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Exercise'),
                    data: "exerciseStudentExerciseId"
                },

                {
                    title: l('Exercise'),
                    data: "exerciseName"
                },
                {
                    title: l('Exercise'),
                    data: "exerciseDueDate",
                    dataFormat: "datetime"

                },
                {
                    title: l('Exercise'),
                    data: "exerciseIsCompleted"
                },
                {
                    title: l('ClassStudentId'),
                    data: "classStudentId"
                },
              
                {
                    title: l('DateOfBirth'),
                    data: "dateOfBirth",
                    dataFormat: "datetime"
                },
                
                {
                    title: l('ClassExercise'),
                    data: "classExercise",
                    render: function (data) {
                        return l('Enum:ClassStudentExercise.' + data);
                    }
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewStudentButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
