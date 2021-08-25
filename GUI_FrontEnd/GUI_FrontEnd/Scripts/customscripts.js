$(function () {

    function DisplayResult1(call, data) {
        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $.each(data, function (i, item) {

            $('#result').append(JSON.stringify(item));
            $('#result').append("<br/>");
        });
    };

    function DisplayResult2(call, data) {
        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $('#result').append(JSON.stringify(data));
        $('#result').append("<br/>");

    };
    
    var serviceUrl = "https://localhost:44395/api";
    $('#GetAll').on('click', function () {
        //alert("Hello");
        $.ajax({
            url: serviceUrl + '/students',
            method: 'GET',
            success: function (data) {
                DisplayResult1("Get All:", data);
            }
        });
    });

    $('#GetById').on('click', function () {
        var studentId = $('#Id').val();
        $.ajax({
            url: serviceUrl + '/students/ ' + studentId,
            method: 'GET',
            success: function (data) {
                DisplayResult2("Student by id:", data);
            }
        });
    });

    $('#GetByLastName').on('click', function () {
        var studentLastName = $('#LastName').val();
        $.ajax({
            url: serviceUrl + '/students/?lastname=' + studentLastName,
            method: 'GET',
            success: function (data) {
                DisplayResult2("Student by last name:", data);
            }
        });
    });

    $('#GetByFirstNameAndCourses').on('click', function () {
        var studentFirstName = $('#FirstName').val();
        var numberOfCourses = $('#NumberofCourses').val();
        $.ajax({
            url: serviceUrl + '/students/?firstname=' + studentFirstName + '&NumberOfCourses=' + numberOfCourses,
            method: 'GET',
            success: function (data) {
                DisplayResult2("Student by first name and number of courses:", data);
            }
        });
    });

    $('#RemoveById').on('click', function () {
        var studentId = $('#Id').val();
        $.ajax({
            url: serviceUrl + '/students/ ' + studentId,
            method: 'DELETE',
            success: function (data) {
                DisplayResult2("the information is removed:", data);
            }
        });
    });


    $('#AddStudent').on('click', function () {
        var inputData = $('input').serialize();
        $.ajax({
            url: serviceUrl + '/students/',
            method: 'POST',
            data: inputData,
            success: function (data) {
                DisplayResult2("Add Student", data);
            }
        });
    });


    $('#UpdateStudent').on('click', function () {
        var inputData = $('input').serialize();
        var studentId = $('#Id').val();
        $.ajax({
            url: serviceUrl + '/students/' + studentId,
            method: 'PUT',
            data: inputData,
            success: function (data) {
                DisplayResult1("Updated list:", data);
            }
        });
    });

});