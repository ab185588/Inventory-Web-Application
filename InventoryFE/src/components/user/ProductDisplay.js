import React, { useEffect, useState } from "react";
import Product from "../Product";
import axios from "axios";
import NavigationBar from "../NavigationBar";

function ProductDisplay() {
  const [data, setData] = useState([]);

  useEffect(() => {
    axios
      .get("https://localhost:44388/api/Products/ProductList")
      .then((res) => {
        console.log(res.data.listProducts);
        setData(res.data.listProducts);
      })
      .catch((err) => console.log(err));
  }, []);

  return (
    <>
      <NavigationBar></NavigationBar>
      
        <div>
          {data.map((item, index) => (
            <Product
        name={item.name}
        price={item.price}
        image="https://www.shutterstock.com/image-illustration/background-silver-metal-chain-common-shortlink-2157127707"
      />
          ))}
        </div>
    
    </>
  );
}

export default ProductDisplay;
