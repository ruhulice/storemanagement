import React, { useEffect, useState } from "react";
import api from "../../api/api";
import { useForm } from "react-hook-form";

const RequisitionForm = () => {
  const [prodcts, setProduct] = useState([]);
  const { register, handleSubmit } = useForm({
    defaultValues: {},
  });

  api
    .get("product")
    .then((res) => setProduct(res.data))
    .catch((error) => console.log(error));
  useEffect(() => {}, []);
  const handleForm = (data) => {
    console.log(data);
  };
  return (
    <div className="container mt-3">
      <form className="p-3 border rounded" onSubmit={handleSubmit(handleForm)}>
        <div className="row mb-3">
          <div className="col-md-6">
            <label className="form-label">Product</label>
            <select
              className="form-control"
              {...register("productId", { required: true })}
            >
              <option value="">Select Product</option>
              {prodcts.map((item) => (
                <option key={item.id} value={item.id}>
                  {item.productName}
                </option>
              ))}
            </select>
          </div>
          <div className="col-md-6">
            <label className="form-label">Quantity</label>
            <input
              className="form-control"
              type="text"
              {...register("requestedQuantity", { required: true })}
            />
          </div>
        </div>
        <div className="row mb-3">
          <div className="col-md-6">
            <label className="form-label">Unit of Measure</label>
            <select
              className="form-control"
              {...register("uom", { required: true })}
            >
              <option value="">Select UOM</option>
              <option value="Piece">Piece</option>
              <option value="Ream">Ream</option>
              <option value="Box">Box</option>
              <option value="Set">Set</option>
            </select>
          </div>
        </div>
      </form>
    </div>
  );
};

export default RequisitionForm;
