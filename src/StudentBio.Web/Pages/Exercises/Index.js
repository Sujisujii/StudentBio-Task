$(function () {
    var l = abp.localization.getResource('StudentBio');
    var createModal = new abp.ModalManager(abp.appPath + 'Exercises/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Exercises/EditModal');

    var dataTable = $('#ExercisesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(studentBio.exercises.exercise.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible:
                                        abp.auth.isGranted('StudentBio.Exercises.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible:
                                        abp.auth.isGranted('StudentBio.Exercises.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'ExerciseDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        studentBio.exercises.exercise
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('StudentExerciseId'),
                    data: "studentExerciseId"
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('DueDate'),
                    data: "dueDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: l('IsCompleted'),
                    data: "isCompleted"
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

    $('#NewExerciseButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
