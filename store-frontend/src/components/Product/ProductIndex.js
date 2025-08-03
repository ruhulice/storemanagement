import React, { useEffect, useState } from "react";
import api from "../../api/api";
import { useNavigate } from "react-router-dom";

const ProductIndex = () => {
  const [products, setProduct] = useState([]);
  const navigate = useNavigate();
  useEffect(() => {
    api
      .get("product")
      .then((res) => setProduct(res.data))
      .catch((err) => console.log(err));
  }, []);
  //  console.log(products);
  return (
    <div className="container mt-3">
      <button
        type="button"
        className="btn btn-primary mb-3"
        onClick={() => navigate("/products/create")}
      >
        Add New
      </button>
      <table className="table table-bordered table-striped">
        <thead className="table-secondary">
          <tr>
            <th>Id</th>
            <th>Product Name</th>
            <th>UOM</th>
            <th>SubCategory</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {products.map((item) => (
            <tr key={item.id}>
              <td> {item.id}</td>
              <td> {item.productName}</td>
              <td>{item.uom}</td>
              <td>{item.subCategoryId}</td>
              <td>{item.description}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ProductIndex;
