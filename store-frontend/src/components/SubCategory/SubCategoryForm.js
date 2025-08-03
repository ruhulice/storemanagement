import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import api from "../../api/api";
import { toast } from "react-toastify";

const SubCategoryForm = () => {
  const { register, handleSubmit } = useForm({
    defaultValues: {
      id: 0,
      subCategoryName: "",
      categoryId: "",
    },
  });
  const [categoies, setCategory] = useState([]);

  const onSubmit = async (data) => {
    const postData = {
      id: 0,
      subCategoryName: data.subCategoryName,
      categoryId: Number(data.categoryId), // ensure number type
    };

    console.log(postData);

    try {
      // Using axios instance called `api`
      await api.post("/subcategory", postData);
      toast.success("Save successfully");
      navigate("/subcategories");
    } catch (error) {
      console.error("Error posting data:", error);
      // Optional: If error response from server:
      if (error.response) {
        console.error("Server responded with:", error.response.data);
        toast.error("Fail to save data");
      }
    }
  };

  const navigate = useNavigate();
  useEffect(() => {
    api
      .get("/category")
      .then((res) => setCategory(res.data))
      .catch((err) => {
        console.log("Data fetch problem" + err);
      });
  }, []);
  console.log(categoies);
  return (
    <>
      <div className="container mt-3">
        <h2>Create SubCategory</h2>
        <form onSubmit={handleSubmit(onSubmit)} className="p-4 border rounded">
          <div className="mb-3">
            <label className="form-label">SubCategory Name</label>
            <input
              className="form-control"
              {...register("subCategoryName", { required: true })}
              placeholder="Subcategory Name"
              defaultValue="test"
            />
          </div>
          <div className="mb-3">
            <label className="form-label">Caategory Id</label>
            <select
              {...register("categoryId", { required: true })}
              className="form-control"
            >
              <option value=""> Select Category </option>
              {categoies.map((cat) => (
                <option key={cat.id} value={cat.id}>
                  {cat.categoryName}
                </option>
              ))}
            </select>
          </div>
          <button type="submit" className="btn btn-primary">
            Save
          </button>
          <button
            type="button"
            className="btn btn-warning ms-2"
            onClick={() => navigate("/subcategories")}
          >
            Back
          </button>
        </form>
      </div>
    </>
  );
};

export default SubCategoryForm;
