import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Login from "./Login";
import Registration from "./Registration";
import DashBoard from "./user/DashBoard";
import Orders from "./user/Orders";
import Profile from "./user/Profile";
import Cart from "./user/Cart";
import ProductDisplay from "./user/ProductDisplay";

import AdminDashboard from "./admin/AdminDashboard";
import AdminOrders from "./admin/AdminOrders";
import Products from "./admin/Products";
import CustomersList from "./admin/CustomersList";
import Analytics from "./admin/Analytics";
import UpdateUser from "./user/UpdateUser";



export default function RoutePage(params) {
  return (
    <>
      <Router>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/Registration" element={<Registration />} />
          <Route path="/DashBoard" element={<DashBoard />} />
          <Route path="/Orders" element={<Orders />} />
          <Route path="/Profile" element={<Profile />} />
          <Route path="/Cart" element={<Cart />} />
          <Route path="/Profile" element={<Profile />} />
          <Route path="/UpdateUser" element={<UpdateUser />} />
          <Route path="/ProductDisplay" element={<ProductDisplay />} />
          <Route path="/AdminDashboard" element={<AdminDashboard />} />
          <Route path="/AdminOrders" element={<AdminOrders />} />
          <Route path="/CustomersList" element={<CustomersList />} />
          <Route path="/Products" element={<Products />} />
          <Route path="/Analytics" element={<Analytics />}></Route>
        </Routes>
      </Router>
    </>
  );
}
