import React from "react";
import { NavLink } from "react-router-dom";
import "../App.css";

function Sidebar() {
  return (
    <div className="sidebar border-end">
      <div className="list-group list-group-flush">
        <NavLink
          to="/"
          className={({ isActive }) =>
            isActive
              ? "list-group-item list-group-item-action active-link"
              : "list-group-item list-group-item-action inactive-link"
          }
        >
          Dashboard
        </NavLink>
        <NavLink
          to="/stocks"
          className={({ isActive }) =>
            isActive
              ? "list-group-item list-group-item-action active-link"
              : "list-group-item list-group-item-action inactive-link"
          }
        >
          Stocks
        </NavLink>
        <NavLink
          to="/requisitions"
          className={({ isActive }) =>
            isActive
              ? "list-group-item list-group-item-action active-link"
              : "list-group-item list-group-item-action inactive-link"
          }
        >
          Requisition
        </NavLink>
        <NavLink
          to="/products"
          className={({ isActive }) =>
            isActive
              ? "list-group-item list-group-item-action active-link"
              : "list-group-item list-group-item-action inactive-link"
          }
        >
          Products
        </NavLink>

        <NavLink
          to="/categories"
          className={({ isActive }) =>
            isActive
              ? "list-group-item list-group-item-action active-link"
              : "list-group-item list-group-item-action inactive-link"
          }
        >
          Categories
        </NavLink>
        <NavLink
          to="/subcategories"
          className={({ isActive }) =>
            isActive
              ? "list-group-item list-group-item-action active-link"
              : "list-group-item list-group-item-action inactive-link"
          }
        >
          SubCategories
        </NavLink>
      </div>
    </div>
  );
}

export default Sidebar;

{
  /* <div
      className="border-end"
      style={{ backgroundColor: "#8F9F8F", width: "200px", height: "100vh" }}
    >
      <div className="list-group list-group-flush">
        <Link to="/" className="list-group-item list-group-item-action">
          Dashboard
        </Link>
        <Link to="/products" className="list-group-item list-group-item-action">
          Products
        </Link>
        <Link
          to="/categories"
          className="list-group-item list-group-item-action"
        >
          Categories
        </Link>
        <Link
          to="/subcategories"
          className="list-group-item list-group-item-action"
        >
          SubCategories
        </Link>
      </div>
    </div> */
}
