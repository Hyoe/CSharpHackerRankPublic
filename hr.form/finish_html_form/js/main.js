/* 
    hr.form
 * 
 * Complete the javascript logic below to make the form functional.
 * See each //todo comment
 * 
 * 
 * 
  */


function initForm() {
    //todo: Populate the Role (#ddlRole) select control with the following options
    //  - Display     - Value
    //  ---------------------
    //  - Admin       - 0
    //  - Member      - 1
    //  - Tester      - 2

    var roles = {
        Admin: 0,
        Member: 1,
        Tester: 2
    }

    $('#ddlRole').append(new Option("Select a Role", ""));

    for (var role in roles) {
        $('#ddlRole').append(new Option(role, roles[role]));
    }

    //todo: Create a jQuery UI Autocomplete control for State (#txtState) textbox
    // - Use the states variable for the source
    // https://jqueryui.com/autocomplete/#custom-data

    $("#txtState").autocomplete({
        source: states,
        select: function (event, ui) {
            $('#txtState').val(ui.item.label);
            $('#txtStateCode').val(ui.item.code);
        }
    });
}


function getFormData() {
    //todo: Collect the form data and return an object with the following properties
    // - name       - type
    // -----------------------
    // - userName   - string
    // - fName      - string
    // - lName      - string
    // - role       - integer
    // - stateName  - string
    // - stateCode  - string (Bonus, find a way to get this data)
    // - isActive   - bool

    var data = {
        //todo
        userName: $('#txtUserName').val().trim(),
        fName: $('#txtFirstName').val().trim(),
        lName: $('#txtLastName').val().trim(),
        role: parseInt($(ddlRole).val().trim()),
        stateName: $('#txtState').val().trim(),
        stateCode: $('#txtStateCode').val().trim(),
        isActive: $(chkIsActive).prop('checked')
    };

    //validate the data, if the data is not valid return false
    if (isFormDataValid(data)) {
        return data;
    }
    return null;
}

var resetForm = function () {
    $('#sentSuccessfulMsg').hide();
    $('#formErrorMsg').hide();
    $('#frmCreateMember').each(function () {
        $(this).find(':input').parent().removeClass('has-success has-error');
    });
}

function isFormDataValid(data) {
    //todo: Clear all previous form validation classes and alert messages
    resetForm();

    //todo: Validate the data with the following specifications
    // http://getbootstrap.com/css/#forms-control-validation
    var addValidationClass = function (el, cls) {
        $(el).parent().addClass(cls);
    }

    // - Username must be unique, existing user names are stored in the currentUsers variable
    var validateUsername = function () {
        var arrToLower = currentUsers.map(function (x) {
            return x.toLowerCase();
        });

        if (data.userName.length > 0 && arrToLower.includes(data.userName.toLowerCase()) || (data.userName.length === 0)) {
            addValidationClass('#txtUserName', 'has-error');
            $('#userNameError').show();
            return false;
        }
        else {
            addValidationClass('#txtUserName', 'has-success');
            return true;
        }
    }

    // - First and Last name must be 2 to 25 characters, only alow A-Z and a-z characters
    var verifyName = function (name) {
        var namePattern = new RegExp('^[A-Za-z]{2,25}$');
        if (namePattern.test(name))
            return true
        else
            return false
    }

    var validateFirstName = function () {
        var verifiedFName = verifyName(data.fName);

        if (verifiedFName) {
            addValidationClass('#txtFirstName', 'has-success');
            return true;
        }
        else {
            addValidationClass('#txtFirstName', 'has-error');
            return false;
        }
    }

    var validateLastName = function () {
        var verifiedLName = verifyName(data.lName);

        if (verifiedLName) {
            addValidationClass('#txtLastName', 'has-success');
            return true;
        }
        else {
            addValidationClass('#txtLastName', 'has-error');
            return false;
        }
    }

    // - State must be in the states list variable
    var validateStates = function () {
        var stateLabels = function () {
            var arr = [];
            states.forEach(function (item) {
                arr.push(item.label.toLowerCase())
            });
            return arr;
        }

        if (stateLabels().includes(data.stateName.toLowerCase())) {
            addValidationClass('#txtState', 'has-success');
            return true;
        }
        else {
            addValidationClass('#txtState', 'has-error');
            return false;
        }
    }

    //todo: If the data is not valid notify the user by adding a bootstrap alert message in the form and return false, otherwise return true
    // http://getbootstrap.com/components/#alerts
    var validateUsername = validateUsername();
    var validateFirstName = validateFirstName();
    var validateLastName = validateLastName();
    var validateStates = validateStates();

    if (validateUsername && validateFirstName && validateLastName && validateStates) {
        return true;
    }
    else {
        $('#formErrorMsg').show();
        return false;
    }
}


function postFormData(data) {
    console.log(data);
    //todo: Ignore the data and add a bootstrap alert message to the form notifying the user the data was send successfully
    //http://getbootstrap.com/components/#alerts
    currentUsers.push(data.userName);
    $('#sentSuccessfulMsg').show();
}

/////////////////////////////////////////////////////////////////////////////////
//           Do not modify code below this point
/////////////////////////////////////////////////////////////////////////////////

//list of acceptable states for the state input
var states = [
    { code: "CA", label: "California" },
    { code: "AK", label: "Alaska" },
    { code: "AZ", label: "Arizona" }
];

//Current Usernames that are not allowed to be entered
var currentUsers = ["Billy", "Bob", "Joe"];

function onBtnSubmitClicked() {
    var data = getFormData();
    if (data != null) {
        postFormData(data);
    }
}

$(function () {
    //init the form
    initForm();

    //register the form
    $("#btnSubmit").on('click', onBtnSubmitClicked);
});