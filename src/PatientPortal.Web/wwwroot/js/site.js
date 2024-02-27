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
    });
});
