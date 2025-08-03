import React, { useState } from "react";
import api from "../../api/api";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

function CategoryForm() {
  const [category, setCategory] = useState({
    Id: 0,
    CategoryName: "",
    CategoryCode: "",
    Remarks: "",
    Iuser: "",
  });

  const navigate = useNavigate();

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setCategory({ ...category, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.post("/category", category);
      setCategory({
        Id: 0,
        CategoryName: "",
        CategoryCode: "",
        Remarks: "",
        Iuser: "",
      });
      // Navigate to the categories page
      toast.success("Save successfully");
      navigate("/categories");
    } catch (error) {
      console.error(
        "There was an error saving the category",
        error.response?.data || error.message
      );
      toast.error("Fail to save data");
    }
  };

  return (
    <div className="container mt-3">
      <h2>Create Category</h2>
      <form onSubmit={handleSubmit} className="p-4 border rounded">
        <div className="mb-3">
          <label className="form-label">Category Name</label>
          <input
            className="form-control"
            type="text"
            name="CategoryName"
            value={category.CategoryName}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Category Code</label>
          <input
            className="form-control"
            type="text"
            name="CategoryCode"
            value={category.CategoryCode}
            onChange={handleInputChange}
            required
          />
        </div>

        <button type="submit" className="btn btn-primary">
          Save
        </button>
        <button
          type="button"
          className="btn btn-warning ms-2"
          onClick={() => navigate("/categories")}
        >
          Back
        </button>
      </form>
    </div>
  );
}

export default CategoryForm;
