$(document).on('change', '.btn-file :file', function () {
    var input = $(this),
        numFiles = input.get(0).files ? input.get(0).files.length : 1,
        label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
    input.trigger('fileselect', [numFiles, label]);
});

$(function () {
    $('.btn-file :file').on('fileselect', function (event, numFiles, label) {

        var input = $(this).parents('.input-group').find(':text'),
            log = numFiles > 1 ? numFiles + ' files selected' : label;

        if (input.length) {
            input.val(log);
        } else {
            if (log) alert(log);
        }

    });

});
$(function () {


    function disableBack() { window.history.forward() }

    window.onload = disableBack();
    window.onpageshow = function (evt) { if (evt.persisted) disableBack() }

    //turn off autocomplete
    $('form,input,select,textarea').attr("autocomplete", "off");


    //Start datetime

    $('input.datetimepicker').datetimepicker(); //datetime

    $('input.datepicker').datetimepicker(//date

      { format: 'MMM/DD/YYYY' }
      );



    $('input.timepicker').datetimepicker(  //datetime

       { format: 'LT' }
       );


    //End datetime


    //Start datetime url

    $('input.datepickerurl').datetimepicker(//date

     { format: 'MMM-DD-YYYY' }
     );

    //End datetime url


});