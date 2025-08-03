import React from "react";
import { useNavigate } from "react-router-dom";

const RequisitionIndex = () => {
  const navigate = useNavigate();
  return (
    <div className="container mt-3">
      <button
        type="button"
        className="btn btn-primary mb-3"
        onClick={() => navigate("/requisitions/create")}
      >
        Add New
      </button>
      <table className="table table-bordered table-striped">
        <thead className="table-secondary">
          <tr>
            <th>ID</th>
            <th>Requisition Date</th>
            <th>Requisition By</th>
            <th>Status</th>
            <th>Product</th>
            <th>UOM</th>
            <th>Quantity</th>
          </tr>
        </thead>
      </table>
    </div>
  );
};

export default RequisitionIndex;
