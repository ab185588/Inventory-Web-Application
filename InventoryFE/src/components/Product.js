import React from 'react';
import './Product.css';
function Product(props) {
  return (
    <div>
      <h2>{props.name}</h2>
      <p>Price: ${props.price}</p>
      <img src={props.image} alt={props.name} />
    </div>
  );
}

export default Product;