import React,{useEffect, useState} from 'react';
import { MDBCol, MDBContainer, MDBRow, MDBCard, MDBCardTitle, MDBCardText, MDBCardBody, MDBCardImage, MDBBtn } from 'mdb-react-ui-kit';
import NavigationBar from '../NavigationBar';
import { useNavigate } from 'react-router-dom';




export default function Profile() {

    let navigate = useNavigate();

   
    const[firstname,Setfname]=useState("fname");
    const[lastname,Setlname]=useState("lname");
    const[email,setemail]=useState("email");

    useEffect(()=>{
      setemail(localStorage.getItem("email"));
      Setfname(localStorage.getItem("fname"));
      Setlname(localStorage.getItem("lname"));
    },[]);

 

    const HandleClick = ()=>{
      navigate("/UpdateUser")
    };

  
  return (
    <>
    <NavigationBar/>
    <div className="vh-100" style={{ backgroundColor: '#9de2ff' }}>
      <MDBContainer>
        <MDBRow className="justify-content-center">
          <MDBCol md="9" lg="7" xl="5" className="mt-5">
            <MDBCard style={{ borderRadius: '15px' }}>
              <MDBCardBody className="p-4">
                <div className="d-flex text-black">
                  <div className="flex-shrink-0">
                    <MDBCardImage
                      style={{ width: '180px', borderRadius: '10px' }}
                      src='https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-profiles/avatar-1.webp'
                      alt='Generic placeholder image'
                      fluid />
                  </div>
                  <div className="flex-grow-1 ms-3">
                    <MDBCardTitle>{email}</MDBCardTitle>
                    <MDBCardText>{firstname}</MDBCardText>
                    <MDBCardText>{lastname}</MDBCardText>
                    <MDBBtn onClick={()=>HandleClick()}> Update Profile</MDBBtn>
                  </div>
                </div>
              </MDBCardBody>
            </MDBCard>
          </MDBCol>
        </MDBRow>
      </MDBContainer>
    </div>
    </>
  );
}


