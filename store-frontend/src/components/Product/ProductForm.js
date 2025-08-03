import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import api from "../../api/api";
import { toast } from "react-toastify";

const ProductForm = () => {
  const { register, handleSubmit } = useForm({
    defaultValues: {
      id: 0,
      productName: "",
      uom: "",
      description: "",
      subCategoryId: "",
    },
  });
  const [subCategory, setSubCategory] = useState([]);
  const navigate = useNavigate();
  useEffect(() => {
    api
      .get("subcategory")
      .then((res) => setSubCategory(res.data))
      .catch((err) => console.log(err));
  }, []);
  const onSubmitForm = async (data) => {
    const postData = {
      id: 0,
      productName: data.productName,
      uom: data.uom,
      description: data.description,
      subCategoryId: data.subCategoryId,
    };
    console.log(postData);
    try {
      await api.post("/product", postData);
      toast.success("Save successfully");
      navigate("/products");
    } catch (error) {
      console.error("Error saving product", error.response.data);
      if (error.response) {
        if ((error.response.status = 400)) {
          toast.error(error.response.data);
        } else if ((error.response.status = 400)) {
          toast.error(error.response.data);
        } else {
          toast.error(error.response.data);
        }
      }
      toast.error(error.response.data);
    }
  };
  return (
    <div className="container mt-3">
      <h2>Create product</h2>
      <form
        onSubmit={handleSubmit(onSubmitForm)}
        className="p-3 border rounded"
      >
        <div className="mb-3">
          <label className="form-label">Category</label>
          <select
            className="form-control"
            {...register("subCategoryId", { required: true })}
          >
            <option value="">Select Category</option>
            {subCategory.map((cat) => (
              <option key={cat.id} value={cat.id}>
                {cat.subCategoryName}
              </option>
            ))}
          </select>
        </div>
        <div className="mb-3">
          <label className="form-label">Product Name</label>
          <input
            className="form-control"
            {...register("productName", { required: true })}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Unit of Measurement </label>
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
        <div className="mb-3">
          <label className="form-label">Description</label>
          <input className="form-control" {...register("description")} />
        </div>
        <button type="submit" className="btn btn-primary">
          Save
        </button>
        <button
          type="button"
          className="btn btn-warning ms-2"
          onClick={() => navigate("/products")}
        >
          Back
        </button>
      </form>
    </div>
  );
};

export default ProductForm;
