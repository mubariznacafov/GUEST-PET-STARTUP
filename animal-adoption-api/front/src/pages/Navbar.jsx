import React from "react";
import { Link } from "react-router-dom";
import AdoptMeLogo from "../assets/icons/adopt_me_black.png";
import "../scss/layout/navbar/_navbar.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUser } from "@fortawesome/free-solid-svg-icons";
const Navbar = () => {
  return (
    <div className="navbar">
      <div className="navbarLogo">
        <Link to={"/"}>
          <img src={AdoptMeLogo} alt="adopt-me-logo" />
        </Link>
      </div>
      <div className="centerLinks">
        <Link to={"/"}>HOME</Link>
        <Link to={"/veterinary"}>VETERINARY</Link>
        <Link to={"/blog"}>BLOG</Link>
        <Link to={"/zoo-shop"}>ZOO SHOP</Link>
        <Link to={"/profile"}>PROFILE</Link>
        <Link to={"/favorites"}>FAVORITES</Link>
      </div>
      <div className="rightLink">
        <Link to={"/add-name"}>
          <FontAwesomeIcon icon={faUser} />
        </Link>
      </div>
    </div>
  );
};

export default Navbar;
