import React, { useEffect, useState } from "react";
import api from "../../api/api";
import { useNavigate } from "react-router-dom";

const SubCategoryIndex = () => {
  const [subCategories, setSubCategory] = useState([]);
  const navigate = useNavigate();
  useEffect(() => {
    //console.log("Fetching subcategory");
    api
      .get("subcategory")
      .then((response) => setSubCategory(response.data))
      .catch((error) => console.log("Erroe" + error));
  }, []);
  //console.log(subCategories);
  return (
    <>
      <div className="container mt-3">
        <button
          type="button"
          className="btn btn-primary mb-3"
          onClick={() => navigate("/subcategories/create")}
        >
          Add New
        </button>

        <table className="table table-bordered table-striped">
          <thead className="table-secondary">
            <tr>
              <th>ID</th>
              <th>SubCategory Name</th>
              <th>category Name</th>
            </tr>
          </thead>
          <tbody>
            {subCategories.map((item) => (
              <tr key={item.id}>
                <td>{item.id}</td>
                <td>{item.subCategoryName}</td>
                <td>{item.categoryName}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
};

export default SubCategoryIndex;
