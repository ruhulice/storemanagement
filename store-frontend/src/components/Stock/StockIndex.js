import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../../api/api";

const StockIndex = () => {
  const navigate = useNavigate();
  const [stocks, setStock] = useState([]);
  useEffect(() => {
    api
      .get("stocks")
      .then((res) => setStock(res.data))
      .catch((error) => console.log(error));
  }, []);
  return (
    <div className="container mt-3">
      <button
        type="button"
        className="btn btn-primary mb-3"
        onClick={() => navigate("/stocks/create")}
      >
        Add New
      </button>
      <table className="table table-bordered table-triped">
        <thead className="table-secondary">
          <tr>
            <th>Id</th>
            <th>Product</th>
            <th>Stock Quantity</th>
            <th>Unit of Measurement</th>
            <th>Reorder Level</th>
            <th>Blocked Quantity</th>
          </tr>
        </thead>
        <tbody>
          {stocks.map((item) => (
            <tr key={item.id}>
              <td>{item.id}</td>
              <td>{item.product}</td>
              <td>{item.stockQuantity}</td>
              <td>{item.uom}</td>
              <td>{item.reorderLevel}</td>
              <td>{item.blockQuantity}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default StockIndex;
