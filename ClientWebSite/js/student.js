//#region Global Variables
var urlStudent = "http://127.0.0.1:5289/api/Student/";
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

class Student {
  id;
  name;
  age;
  address;
  image;
  departmentName;
  constructor(id, name, age, address, image, departmentName) {
    this.name = name;
    this.age = age;
    this.address = address;
    this.image = image;
    this.departmentName = departmentName;
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
class StudentCreate {
  name;
  age;
  address;
  image;
  departmentId;
  constructor(name, age, address, image, departmentId) {
    this.name = name;
    this.age = age;
    this.address = address;
    this.image = image;
    this.departmentId = departmentId;
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

function getStudent() {
  var name = document.getElementById("name_input").value;
  var age = document.getElementById("age_input").value;
  var address = document.getElementById("address_input").value;
  var image = document.getElementById("img_input").value;
  var departmentId = document.getElementById("dept_input").value;
  if (
    checkStr(name) &&
    checkStr(address) &&
    checkStr(image) &&
    checkNumber(age)
  ) {
    var stu = new StudentCreate(
      name,
      Number(age),
      address,
      image,
      Number(departmentId)
    );
    document.getElementById(`push_std`).setAttribute("data-stu", 0);
    return stu;
  } else {
    warningChange("All Inputs must be valid", "error");
    return null;
  }
}

function updateStudent(e) {
  var id = e.id.split("_")[1];
  document.getElementById("name_input").value = document.getElementById(
    `stu_name_${id}`
  ).innerText;
  document.getElementById("age_input").value = document.getElementById(
    `stu_age_${id}`
  ).innerText;
  document.getElementById("address_input").value = document.getElementById(
    `stu_address_${id}`
  ).innerText;
  document.getElementById("img_input").value = document.getElementById(
    `stu_image_${id}`
  ).innerText;
  var dept_id = deptList.filter(
    (d) => d.name == document.getElementById(`stu_dept_${id}`).innerText
  )[0].id;
  var sel = document.getElementById("dept_input");
  sel.value = dept_id;
  var opts = sel.children;

  for (let i = 0; i < opts.length; i++) {
    if (opts[i].value == dept_id) opts[i].selected = true;
  }
  var btn = document.getElementById(`push_std`);
  btn.innerText = "Update Student";
  btn.setAttribute("data-stu", `${id}`);
}
//#endregion

//#region Row Table
var dataCont = document.getElementById("tb_content");
var divCont = document.getElementById("table_sh");

function createRow(student) {
  return `<td id="stu_name_${student.id}">${student.name}</td>
    <td id="stu_age_${student.id}">${student.age}</td>
    <td id="stu_address_${student.id}">${student.address}</td>
    <td id="stu_image_${student.id}">${student.image}</td>

    <td id="stu_dept_${student.id}">${student.departmentName}</td>
    <td>
      <button id='edit_${student.id}' onclick='updateStudent(this)' class="btn btn-warning text-white ps-5 pe-5">
        Edit
      </button>
    </td>
    <td>
      <button id='del_${student.id}' onclick='deleteStudent(this)' class="btn btn-danger text-white ps-5 pe-5">
        Delete
      </button>
    </td>`;
}

function addRow(student) {
  divCont.hidden = false;
  dataCont.innerHTML += `  <tr id='student_${student.id}'>${createRow(
    student
  )}</tr>`;
}
function deleteRow(id) {
  var rec_data = document.getElementById(`student_${id}`);

  dataCont.removeChild(rec_data);
  if (dataCont.children.length == 0) divCont.hidden = true;
}

function updateRow(student) {
  document.getElementById(`student_${student.id}`).innerHTML =
    createRow(student);
  document.getElementById(`push_std`).innerText = "Add Student";
}

function addDepartment(departments) {
  var selects = document.getElementById("dept_input");
  departments.forEach(
    (dept) =>
      (selects.innerHTML += ` <option  value=${dept.id} >${dept.name}</option>`)
  );
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
        if (deptList.length != 0) addDepartment(deptList);
      } else if (request.status == 404) warningChange((msg = request.response));
      else if (request.status == 505)
        warningChange((msg = request.response), "error");
    }
  };
  request.onerror = function () {
    alert(`Network Error`);
  };
}
function getStudents() {
  var request = new XMLHttpRequest();
  request.open("GET", `${urlStudent}`);
  request.send();
  request.onload = function () {
    if (request.readyState == 4) {
      if (request.status == 200) {
        var studentList = JSON.parse(request.response, new Student());
        if (studentList.length != 0) {
          dataCont.innerHTML = "";
          studentList.forEach((element) => addRow(element));
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
function getAll() {
  getDepartments();
  getStudents();
}
window.onload = getAll;

function addStudent() {
  var id = Number(document.getElementById(`push_std`).getAttribute("data-stu"));
  if (id == 0) {
    var student = getStudent();
    if (student != null) {
      var request = new XMLHttpRequest();
      request.open("POST", `${urlStudent}Add`);
      request.setRequestHeader("Content-Type", "application/json");

      request.send(JSON.stringify(student)); // from div Inputs
      request.onload = function () {
        if (request.readyState == 4) {
          if (request.status == 200) getStudents();
          else warningChange((msg = request.response), "error");
        }
      };
    }
  } else {
    var student = getStudent();
    var request = new XMLHttpRequest();
    request.open("PUT", `${urlStudent}Update/?id=${id}`);
    request.setRequestHeader("Content-Type", "application/json");

    var StudentUp = {
      [Enum.Name]: student.name,
      [Enum.Age]: `${student.age}`,
      [Enum.Address]: student.address,
      [Enum.Image]: student.image,
      [Enum.DepartmentId]: `${student.departmentId}`,
    };
    request.send(JSON.stringify(StudentUp)); // from div Inputs
    request.onload = function () {
      if (request.readyState == 4) {
        if (request.status == 200) {
          var studentShow = new Student(
            id,
            student.name,
            student.age,
            student.address,
            student.image,
            deptList.filter((d) => d.id == student.departmentId)[0].name
          );
          updateRow(studentShow);
        } else warningChange((msg = request.response), "error");
      }
    };
  }
}

function deleteStudent(e) {
  var id = e.id.split("_")[1];
  var request = new XMLHttpRequest();
  request.open("DELETE", `${urlStudent}Delete`);
  request.setRequestHeader("Content-Type", "application/json");
  request.send(JSON.stringify(Number(id)));
  request.onload = function () {
    if (request.readyState == 4 && request.status == 200) {
      deleteRow(id);
    } else warningChange((msg = request.response), "error");
  };
}
//#endregion
