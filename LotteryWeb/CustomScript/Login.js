$(document).on('click', '#btnSignUp', function () {
    if (ValidateSignUpUser()) {
        $(this).prop('disabled', true);
        var temptext = $(this).text();
        $(this).text('Processing...');
        var json = {
            UserId: 0,
            Name: $('#signup_name').val(),
            Email: $('#signup_email').val(),
            Phone: $('#signup_phone').val(),
            Password: $('#signup_password').val()
        }
        $.post('/Register', json, function (Response) {
            if (Response) {
                $('#signupModal').modal('hide');
                $('input').val('');
                ShowAlert('Updated', 'Account Created Successfully!. Please login', 'success');
            }
            else {
                ShowAlert('Processing failed!', 'Account Creation failed', 'error');
            }
            $('#btnSignUp').text(temptext);
            $('#btnSignUp').prop('disabled', false);
        })
    }
})

$(document).on('hidden.bs.modal', '#login', function (e) {
    $("#txtUserName").val('');
    $("#txtPassword").val('');
    
    $('#btnsignin').text('Login');
})
$(document).on('hidden.bs.modal', '#Forgotpassword', function (e) {
    $("#txtForgetUserName").val('');
    $('#btnforgot').text('Forgot password');
})
function FocusErrors(Id) {
    
    $("#" + Id).val($("#" + Id).prop('type') == "select-one"?"0":"");
    $("#" + Id).focus();
    $("#" + Id).addClass('error-field');
    $('#span-' + Id).show();
}
function ValidateSignUpUser() {
    var valid = true;
    $('.error-message').hide();
    $('.form-control').removeClass('error-field');
    if ($("#signup_email").val() == "") {
        valid = false;
        FocusErrors('signup_email');
    }
    if ($("#signup_name").val() == "") {
        valid = false;
        FocusErrors('signup_name');
    }
    if ($("#signup_phone").val() == "") {
        valid = false;
        FocusErrors('signup_phone');
    }
    if ($("#signup_password").val() == "") {
        valid = false;
        FocusErrors('signup_password');
    }
    return valid;
}
function ValidateSigninUser() {
    var valid = true;
    $('.error-message').hide();
    $('.form-control').removeClass('error-field');
    if ($("#txtUserName").val() == "") {
        valid = false;
        FocusErrors('txtUserName');
    }
    if ($("#txtPassword").val() == "") {
        valid = false;
        FocusErrors('txtPassword');
    }
    


    return valid;
}
function ValidateForgetUser() {
    var valid = true;
    $('.error-message').hide();
    $('.form-control').removeClass('error-field');
    if ($("#txtForgetUserName").val() == "") {
        valid = false;
        FocusErrors('txtForgetUserName');
    }
    
    return valid;
}
$(document).on('click', '#btnsignin', function () {
    if (ValidateSigninUser()) {
        $(this).prop('disabled', true);
        var temptext = $(this).text();
        $(this).text('Processing...');

        var json = {
            Email: $('#txtUserName').val(),
            Password: $('#txtPassword').val(),
        }
        $.post('/Login', json, function (Response) {
            if (Response.UserId > 0 && $('#txtUserName').val()!='admin') {
                location.reload();
            }
            else {
                $('#loginModal').modal('hide');
                $('#btnsignin').text(temptext);
                $('#btnsignin').prop('disabled', false);
                ShowAlert('Processing failed!', 'Login failed', 'error');
            }
        })
    }
})
$(document).on('click', '#btnforgot', function () {
    if (ValidateForgetUser()) {
        $(this).prop('disabled', true);
        var temptext = $(this).text();
        $(this).text('Processing...');

        var json = {
            Email: $('#txtForgetUserName').val(),
            

        }
        $.post('/Common/ResetUsers', json, function (Response) {


            if (Response) {
                $('#Forgotpassword').modal('hide');
                ShowAlertLoad('Success!', 'one time password reset link sent to your email - id.Please reset a password and login', 'success', location.href);
            }
            else {
                $('#login').modal('hide');
                $('#btnforgetpassword').text(temptext);
                $('#btnforgetpassword').prop('disabled', false);
                ShowAlert('Processing failed!', 'Your username not registered with us! please try with diffrent username', 'error');
            }
        })
    }
})