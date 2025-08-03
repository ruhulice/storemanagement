import React, { useEffect, useState } from "react";
import api from "../../api/api";
import { useNavigate } from "react-router-dom";

function IndexCategory() {
  const [categories, setCategory] = useState([]);
  // const [serachName, setSearchName] = useState("");
  // const [searchDate, setSearchDate] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    // console.log("Fetching categories...");
    api
      .get("category")
      .then((response) => setCategory(response.data))
      .catch((error) =>
        console.error("Error in fetching category data", error)
      );
  }, []);

  //const filteredDate = categories;

  return (
    <>
      <div className="container mt-3">
        <button
          type="button"
          className="btn btn-primary mb-3"
          onClick={() => navigate("/categories/create")}
        >
          Add New
        </button>

        <table className="table table-bordered table-striped">
          <thead className="table-secondary">
            <tr>
              <th>ID</th>
              <th>Category Name</th>
              <th>Category Code</th>
            </tr>
          </thead>
          <tbody>
            {categories.map((item) => (
              <tr key={item.id}>
                <td>{item.id}</td>
                <td>{item.categoryName}</td>
                <td>{item.categoryCode}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
}
export default IndexCategory;
