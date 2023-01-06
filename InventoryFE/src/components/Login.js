import React, {  useState } from "react";
import {MDBContainer, MDBCol, MDBRow, MDBBtn,  MDBInput } from 'mdb-react-ui-kit';
import axios from 'axios';
import { useNavigate } from "react-router-dom";
export default function Login(params) {
    
    let navigate = useNavigate();
    const [email,setemail] = useState("");
    const [password,setpassword] = useState("");
    const  url = 'https://localhost:44388/api/Users/Login';

    

const handleLogin = ()=>{
        const data = {
            EMAIL : email,
            PASSWORD : password
        }
       
        axios.post(url,data).then(
            (response)=>{
                console.log(response);
                if(response.status===200){
                   console.log(response)
                   localStorage.setItem("Id",response.data.user.id)
                   localStorage.setItem("fname",response.data.user.firstname)
                   localStorage.setItem("lname",response.data.user.lastname)
                   localStorage.setItem("email",response.data.user.email)
                  
                    navigate("/DashBoard");
                }
                else if(response.status===100){
                    navigate("/Login")
                }
              })
              .catch(function (error) {
                console.log(error);
        });
      

    }

    const handleRegister = ()=>{
     navigate("/Registration");
    }



    return (
      <>
    <MDBContainer  fluid className="p-3 my-5 d-flex flex-column w-50">
        
      <MDBRow>
        <MDBCol col='4' md='6'>

          <MDBInput wrapperClass='mb-4' label='Email address' id='formControlLg' type='email' size="lg" onChange={(e)=>{setemail(e.target.value)}}/>
          <MDBInput wrapperClass='mb-4' label='Password' id='formControlLg' type='password' size="lg" onChange={(e)=>{setpassword(e.target.value)}}/>

          <div className="d-flex justify-content-between mb-4">
            <a href="!#">Forgot password?</a>
          </div>

          <div className='text-center text-md-start mt-4 pt-2 d-flex justify-content-sm-between'>
            <MDBBtn className="mb-0 px-5 .mx-auto"  onClick={()=>handleLogin()}>Login</MDBBtn>
            <MDBBtn className="mb-0 px-5 .mx-3" onClick={()=>handleRegister()}>Register</MDBBtn>
          </div>

        </MDBCol>
      </MDBRow>
    </MDBContainer>
    </>
  );
}


