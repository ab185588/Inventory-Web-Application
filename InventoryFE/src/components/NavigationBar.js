import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import "../App.css";

const NavigationBar = () => {

  let navigate=useNavigate();
 
  const handleChange = ()=>{
    navigate("/")
    localStorage.clear();
  }

  return (
    <div className="d-block justify-content-start .ps-12" >

      <nav className="nav">
        <ul>
          <li>
            <a href="/Admin">Admin</a>
          </li>

          <li>
            <a href="/Orders">Orders</a>
          </li>

          <li>
            <a href="/Profile"> Profile</a>
          </li>

          <li>
            <a href="/ProductDisplay">ProductDisplay</a>
          </li>

          <li>
            <a href="/Analytics">Analytics</a>
          </li>
          
          <li>
            <a href="/" onClick={()=>handleChange()}>Log Out</a>
          </li>
        </ul>
      </nav>
    </div>
  );
};

export default NavigationBar;
