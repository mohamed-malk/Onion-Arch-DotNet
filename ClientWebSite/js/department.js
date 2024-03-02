//#region Global Variables
var urlDept = "http://127.0.0.1:5289/api/Department/";
deptList = [];
const Enum = {
  Id: "Id",
  Name: "Name",
  Age: "Age",
  Address: "Address",
  Image: "Image",
  DepartmentId: "DepartmentId",
  Department: "Department",
  Location: "Location",
  Manager: "Manager",
  Students: "Students",
};

class DepartmentStudents {
  id;
  name;
  students;
  constructor(id, name, students) {
    this.name = name;
    this.students = students;
    this.id = id;
  }
}
class Department {
  id;
  name;
  location;
  manager;
  constructor(id, name, location, manager) {
    this.id = id;
    this.name = name;
    this.location = location;
    this.manager = manager;
  }
}
class DepartmentCreate {
  name;
  location;
  manager;
  constructor(name, location, manager) {
    this.name = name;
    this.location = location;
    this.manager = manager;
  }
}

function warningChange(msg, type = "warning") {
  var warningModal = document.getElementById(type);
  // e.setAttribute("data-bs-target", "#warning");
  // e.setAttribute("data-bs-toggle", "modal");

  document.getElementById(`${type}_msg`).innerText = msg;
  warningModal.classList.add("show");
  warningModal.style.display = "block";
  warningModal.setAttribute("aria-modal", "true");
  warningModal.setAttribute("role", "dialog");
}

//#endregion

//#region Inputs
function checkStr(str_value) {
  return str_value.length != 0;
}
function checkNumber(num_value) {
  return !isNaN(Number(num_value));
}

function checkInput(e, checFun) {
  var input_type = e.id.split("_")[0];

  var feed = document.getElementById(`${input_type}_feed`);

  if (checFun(e.value)) {
    e.classList.add("is-valid");
    e.classList.remove("is-invalid");
    feed.classList.add("valid-feedback");
    feed.classList.remove("invalid-feedback");
    feed.innerText = "Looks good!";
  } else {
    e.classList.remove("is-valid");
    e.classList.add("is-invalid");
    feed.classList.remove("valid-feedback");
    feed.classList.add("invalid-feedback");

    feed.innerText = `${input_type} must be not ${
      input_type == "age" ? "a string" : "empty"
    }`;
  }
}

function fillInput() {
  document.getElementById("name_input").value = "";
  document.getElementById("mng_input").value = "";
  document.getElementById("address_input").value = "";
}

function getDepartment() {
  var name = document.getElementById("name_input").value;
  var manager = document.getElementById("mng_input").value;
  var location = document.getElementById("address_input").value;
  if (checkStr(name) && checkStr(manager) && checkStr(location)) {
    var dept = new DepartmentCreate(name, location, manager);
    document.getElementById(`push_dept`).setAttribute("data-dept", 0);
    return dept;
  } else {
    warningChange("All Inputs must be valid", "error");
    return null;
  }
}

function updateDepartment(e) {
  var id = e.id.split("_")[1];
  document.getElementById("name_input").value = document.getElementById(
    `dept_name_${id}`
  ).innerText;
  document.getElementById("mng_input").value = document.getElementById(
    `dept_mng_${id}`
  ).innerText;
  document.getElementById("address_input").value = document.getElementById(
    `dept_address_${id}`
  ).innerText;

  var btn = document.getElementById(`push_dept`);
  btn.innerText = "Update Department";
  btn.setAttribute("data-dept", `${id}`);
}
//#endregion

//#region Row Table
var dataCont = document.getElementById("tb_content");
var divCont = document.getElementById("table_dept");

function createRow(department) {
  return `<td id="dept_name_${department.id}">${department.name}</td>
    <td id="dept_mng_${department.id}">${department.manager}</td>
    <td id="dept_address_${department.id}">${department.location}</td>
    
    <td>
      <button id='edit_${department.id}' onclick='updateDepartment(this)' class="btn btn-warning text-white ps-5 pe-5">
        Edit
      </button>
    </td>
    
    <td>
      <button id='del_${department.id}' onclick='deleteManager(this)' class="btn btn-danger text-white  ps-5 pe-5">
        Delete
      </button>
    </td>`;
}

function addRow(department) {
  divCont.hidden = false;
  dataCont.innerHTML += `  <tr id='department_${department.id}' >${createRow(
    department
  )}</tr>`;
}
function deleteRow(id) {
  var rec_data = document.getElementById(`department_${id}`);
  dataCont.removeChild(rec_data);
  if (dataCont.children.length == 0) divCont.hidden = true;
}

function updateRow(department) {
  document.getElementById(`department_${department.id}`).innerHTML =
    createRow(department);
}

//#endregion

//#region API Part with Event

function getDepartments() {
  var request = new XMLHttpRequest();
  request.open("GET", `${urlDept}`);
  request.send();
  request.onload = function () {
    if (request.readyState == 4) {
      if (request.status == 200) {
        deptList = JSON.parse(request.response, new Department());
        if (deptList.length != 0) {
          dataCont.innerHTML = "";
          deptList.forEach((dept) => addRow(dept));
        }
      } else if (request.status == 404) warningChange((msg = request.response));
      else if (request.status == 505)
        warningChange((msg = request.response), "error");
    }
  };
  request.onerror = function () {
    alert(`Network Error`);
  };
}

window.onload = () => {
  getDepartments();
};

function addDepartment() {
  var id = Number(
    document.getElementById(`push_dept`).getAttribute("data-dept")
  );
  if (id == 0) {
    var dept = getDepartment();
    if (dept != null) {
      var request = new XMLHttpRequest();
      request.open("POST", `${urlDept}Add`);
      request.setRequestHeader("Content-Type", "application/json");

      request.send(JSON.stringify(dept)); // from div Inputs
      request.onload = function () {
        if (request.readyState == 4) {
          if (request.status == 200) getDepartments();
          else warningChange((msg = request.response), "error");
        }
      };
    }
    fillInput();
  } else {
    var department = getDepartment();
    var request = new XMLHttpRequest();
    request.open("PUT", `${urlDept}Update/?id=${id}`);
    request.setRequestHeader("Content-Type", "application/json");

    var DepartmentUp = {
      [Enum.Name]: department.name,
      [Enum.Manager]: department.manager,
      [Enum.Location]: department.location,
    };

    request.send(JSON.stringify(DepartmentUp)); // from div Inputs
    request.onload = function () {
      if (request.readyState == 4) {
        if (request.status == 200) {
          var deptShow = new Department(
            id,
            department.name,
            department.location,
            department.manager
          );

          updateRow(deptShow);
        } else warningChange((msg = request.response), "error");
      }
    };
    document.getElementById(`push_dept`).innerText = "Add Department";
    fillInput();
  }
}

function deleteManager(e) {
  var id = e.id.split("_")[1];
  var request = new XMLHttpRequest();
  request.open("DELETE", `${urlDept}Delete`);
  request.setRequestHeader("Content-Type", "application/json");
  request.send(JSON.stringify(Number(id)));
  request.onload = function () {
    if (request.readyState == 4 && request.status == 200) {
      deleteRow(id);
    } else warningChange((msg = request.response), "error");
  };
}
//#endregion
