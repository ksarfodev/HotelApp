export function initCalendar() {
    $(".calendar").datepicker({
        dateFormat: 'mm/dd/yy',
        firstDay: 1
    });

    $(document).on('click', '.date-picker .input', function (e) {
        var $me = $(this),
            $parent = $me.parents('.date-picker');
        $parent.toggleClass('open');


        document.getElementById("date").innerHTML =
            document.getElementById("date").innerText;

        console.log(document.getElementById("date").innerHTML);

    });


    $(".calendar").on("change", function () {
        var $me = $(this),
            $selected = $me.val(),
            $parent = $me.parents('.date-picker');
        $parent.find('.result').children('span').html($selected);
    });
};

export function getDates() {
    let checkIn = document.getElementById("check-in-date").innerText;
    let checkOut = document.getElementById("check-out-date").innerText;
    return { CheckIn: checkIn, CheckOut: checkOut };
}

