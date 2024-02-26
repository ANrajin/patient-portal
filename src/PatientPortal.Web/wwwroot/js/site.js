$(document).ready(function () {
    $("#addAllergies").on('click', function (e) {
        e.preventDefault();
        moveSelectedOptions('select[name=Allergies]', 'select[name=SelectedAllergies]');
    });

    $("#removeAllergies").on('click', function (e) {
        e.preventDefault();
        moveSelectedOptions('select[name=SelectedAllergies]', 'select[name=Allergies]');
    });

    $("#addNcds").on('click', function (e) {
        e.preventDefault();
        moveSelectedOptions('select[name=Ncds]', 'select[name=SelectedNcds]');
    });

    $("#removeNcds").on('click', function (e) {
        e.preventDefault();
        moveSelectedOptions('select[name=SelectedNcds]', 'select[name=Ncds]');
    });

    function moveSelectedOptions(from, to) {
        const selectedOptions = $(from).find('option:selected');

        selectedOptions.clone().appendTo(to);

        selectedOptions.remove();
    }

    $("#patient-form").on('submit', function (e) {
        e.preventDefault();

        const form = $(this);

        let ncds = [];
        let allergies = [];

        $.each($('select[name=SelectedNcds]').find('option'), function (i, opt) {
            ncds.push(Number($(opt).val()))
        });

        $.each($('select[name=SelectedAllergies]').find('option'), function (i, opt) {
            allergies.push(Number($(opt).val()))
        });

        const formData = {
            Name: $(this).find('input[name=Name]').val(),
            DiseasesId: Number($(this).find('select[name=DiseasesId]').val()),
            Epilepsy: Number($(this).find('select[name=Epilepsy]').val()),
            SelectedNcds: ncds,
            SelectedAllergies: allergies
        };

        $.ajax({
            url: 'https://localhost:7243/patients',
            method: 'post',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            beforeSend: function () {
                const btn = $(form).find('button[type=submit]');
                $(btn).attr('disabled', true);
                $(btn).text('Saving...');
            }
        }).done(function (res) {
            window.location.reload();
        }).fail(function (err) {
            console.error(err);
        }).always(function () {
            const btn = $(form).find('button[type=submit]');
            $(btn).attr('disabled', false);
            $(btn).text('Save');
        });

        return false;
    });

    //Datatable
    const dataTable = $("#patientInfo").DataTable({
        processing: true,
        serverSide: true,
        ajax: 'https://localhost:7243/patients',
        displayStart: 1,
        "columnDefs": [
            {
                "orderable": false,
                "targets": 3,
                "render": function (data, type, row) {
                    return `
                        <a href="/home/patients/${data}" class="btn btn-outline-primary" data-bs-toggle="tooltip"
                            data-bs-placement="bottom" title="View Information">
                            View
                        </a>
                        <button type="button" class="btn btn-outline-primary"
                            onclick="" data-bs-toggle="tooltip"
                            data-bs-placement="bottom" title="Edit">
                            Edit
                        </button>
                        <button type="button" class="btn btn-outline-danger delete-btn" data-id=${data}
                            data-bs-toggle="tooltip" data-bs-placement="bottom" title="Trash">
                            Delete
                        </button>
                    `;
                }
            }
        ]
    });

    $("body").on('click', '.delete-btn', function (e) {
        e.preventDefault();

        const id = $(this).data('id');

        if (!confirm("Are you sure to delete?")) return;

        $.ajax({
            url: `https://localhost:7243/patients/${id}`,
            method: 'delete',
        }).done(function (res) {
            window.Location.reload();
        }).fail(function (err) {
            console.error(err);
        });
    });
});
