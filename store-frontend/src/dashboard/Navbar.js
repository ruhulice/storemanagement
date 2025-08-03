import React from "react";
import logo from "../assets/img/iwm.png"; // Correct relative path

function Navbar() {
  return (
    <nav
      className="navbar navbar-expand-lg navbar-dark px-4"
      style={{ backgroundColor: "#607d8b" }}
    >
      <div className="container-fluid">
        <a className="navbar-brand d-flex align-items-center" href="/">
          <img
            src={logo}
            alt="Logo"
            className="me-2"
            style={{ height: "100%" }}
          />
          Store Management
        </a>

        <form className="d-flex ms-auto" role="search">
          <input
            className="form-control me-2"
            type="search"
            placeholder="Search"
            aria-label="Search"
          />
          <button className="btn btn-outline-light" type="submit">
            Search
          </button>
        </form>
      </div>
    </nav>
  );
}

export default Navbar;
