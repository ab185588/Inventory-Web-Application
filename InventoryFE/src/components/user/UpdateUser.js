import React, { useState } from 'react'
import "../../App.css";
import {
  MDBBtn,
  MDBContainer,
  MDBRow,
  MDBCol,
  MDBCard,
  MDBCardBody,
  MDBInput,
} from "mdb-react-ui-kit";
import { useNavigate } from "react-router-dom";
import axios from 'axios'

const UpdateUser = () => {

let navigate = useNavigate();

  const[id,setId]= useState(0);
  const [email, setemail] = useState("");
  const [password, setpassword] = useState("");
  const [firstName, setfirstName] = useState("");
  const [lastName, setlastName] = useState("");
  const url = "https://localhost:44388/api/Users/UpdateUser";


  const handleUpdate= () => {
    const data = {
      ID : id,
      FIRSTNAME: firstName,
      LASTNAME: lastName,
      PASSWORD: password,
      EMAIL: email,
    };

    setId(localStorage.getItem("Id"));
    console.log("clicked");
    axios
      .post(url, data)
      .then((response) => {
        console.log(response.data);
        if (response.status === 200) {
          console.log("200");
          localStorage.setItem("fname",response.data.user.firstname)
          localStorage.setItem("lname",response.data.user.lastname)
          localStorage.setItem("email",response.data.user.email)
          navigate("/Profile");
        } else if (response.status === 100) {
          console.log("100");
          navigate("/Register");
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };
  return (
    <>
    <div style={{
      display:"block",
      justifyContent:"center"
    }}>
      <MDBContainer fluid className="p-4  overflow-hidden d-block justifyContent-center">
        <MDBRow >
          <MDBCol md="6" className="position-relative">
            <MDBCard className="my-5 ">
              <MDBCardBody className="p-5">
                <MDBRow>
                  <MDBCol col="6">
                    <MDBInput
                      wrapperClass="mb-4"
                      label="First name"
                      id="form1"
                      type="text"
                      onChange={(e) => {
                        setfirstName(e.target.value);
                      }}
                    />
                  </MDBCol>

                  <MDBCol col="6">
                    <MDBInput
                      wrapperClass="mb-4"
                      label="Last name"
                      id="form2"
                      type="text"
                      onChange={(e) => {
                        setlastName(e.target.value);
                      }}
                    />
                  </MDBCol>
                </MDBRow>

                <MDBInput
                  wrapperClass="mb-4"
                  label="Email"
                  id="form3"
                  type="email"
                  onChange={(e) => {
                    setemail(e.target.value);
                  }}
                />
                <MDBInput
                  wrapperClass="mb-4"
                  label="Password"
                  id="form4"
                  type="password"
                  onChange={(e) => {
                    setpassword(e.target.value);
                  }}
                />

                <MDBBtn
                  className="w-100 mb-4"
                  size="md"
                  onClick={() => handleUpdate()}
                >
                  update
                </MDBBtn>
              </MDBCardBody>
            </MDBCard>
          </MDBCol>
        </MDBRow>
      </MDBContainer>
      </div>
    </>
  )
}

export default UpdateUser
