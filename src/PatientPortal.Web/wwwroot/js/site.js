$(document).ready(function () {
    $("#addAllergies").on('click', function (e) {
        e.preventDefault();
        moveSelectedOptions('select[name=allergies]', 'select[name=selectedAllergies]');
    });

    $("#removeAllergies").on('click', function (e) {
        e.preventDefault();
        moveSelectedOptions('select[name=selectedAllergies]', 'select[name=allergies]');
    });

    $("#addNcds").on('click', function (e) {
        e.preventDefault();
        moveSelectedOptions('select[name=ncds]', 'select[name=selectedNcds]');
    });

    $("#removeNcds").on('click', function (e) {
        e.preventDefault();
        moveSelectedOptions('select[name=selectedNcds]', 'select[name=ncds]');
    });

    function moveSelectedOptions(from, to) {
        const selectedOptions = $(from).find('option:selected');

        selectedOptions.clone().appendTo(to);

        selectedOptions.remove();
    }

    $("#patient-form").on('submit', function (e) {
        e.preventDefault();

        return false;
    });
});
