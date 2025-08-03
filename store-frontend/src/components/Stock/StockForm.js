import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import api from "../../api/api";
import { toast } from "react-toastify";

const StockForm = () => {
  const { register, handleSubmit } = useForm({
    defaultValues: {
      id: 0,
      productId: "",
      stockQuantity: 0,
      reorderLevel: 0,
    },
  });

  const [product, setProduct] = useState([]);
  const [category, setCategory] = useState([]);
  const [selectedCategoryId, setSelectedCategoryId] = useState(null);

  const navigate = useNavigate();
  useEffect(() => {
    //tetch category
    api
      .get("SubCategory")
      .then((res) => setCategory(res.data))
      .catch((error) => console.log(error));
  }, []);
  useEffect(() => {
    //fetch prodcts
    if (selectedCategoryId) {
      api
        .get(`product/getProductbyCategory?categoryId=${selectedCategoryId}`)
        .then((res) => setProduct(res.data))
        .catch((error) => console.log(error));
    } else {
      setProduct([]);
    }
  }, [selectedCategoryId]);

  const onFormSubmit = async (data) => {
    const postData = {
      id: 0,
      productId: data.productId,
      stockQuantity: data.stockQuantity,
      reorderLevel: data.reorderLevel,
    };
    console.log(postData);
    try {
      await api.post("stocks", postData);
      toast.success("Save successfully");
      navigate("/stocks");
    } catch (error) {
      toast.error(error.response.data);
    }
  };
  return (
    <div className="container mt-3">
      <form
        onSubmit={handleSubmit(onFormSubmit)}
        className="p-3 border rounded"
      >
        <div className="row mb-3">
          <div className="col-md-6">
            <label className="form-label">Category</label>
            <select
              className="form-control"
              onChange={(e) => setSelectedCategoryId(e.target.value)}
            >
              <option value="">Select Category</option>
              {category.map((item) => (
                <option key={item.id} value={item.id}>
                  {item.subCategoryName}
                </option>
              ))}
            </select>
          </div>
          <div className="col-md-6">
            <label className="form-label">Product</label>
            <select
              className="form-control"
              {...register("productId", { required: true })}
            >
              <option value="">Select Product</option>
              {product.map((item) => (
                <option key={item.id} value={item.id}>
                  {item.productName}
                </option>
              ))}
            </select>
          </div>
        </div>
        <div className="row mb-3">
          <div className="col-md-6">
            <label className="form-label">Stock Quantity</label>
            <input
              {...register("stockQuantity", { required: true })}
              type="number"
              className="form-control"
            />
          </div>
          <div className="col-md-6">
            <label className="form-label">Reorder Level</label>
            <input
              {...register("reorderLevel", { required: true })}
              type="number"
              className="form-control"
            />
          </div>
        </div>

        <button type="submit" className="btn btn-primary">
          Save
        </button>
        <button
          type="button"
          className="btn btn-warning ms-2"
          onClick={() => navigate("/stocks")}
        >
          Back
        </button>
      </form>
    </div>
  );
};

export default StockForm;
