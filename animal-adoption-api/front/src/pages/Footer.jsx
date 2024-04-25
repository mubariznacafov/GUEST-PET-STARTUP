import React from "react";
import "../scss/layout/footer/_footer.scss";
import whiteIcon from "../assets/icons/adopt_me_white.png";
const Footer = () => {
  return (
    <div className="footer">
      <div className="icon">
        <div className="img">
          <img src={whiteIcon} alt="" />
        </div>
        <div className="guestPet">
          <h1>Guest Pet</h1>
        </div>
      </div>
      <div className="footerLinks">
        <div className="onlineShopping">
          <h3>ONLINE SHOPPING</h3>
          <ul>
            <li>
              <a>For Dogs</a>
            </li>
            <li>
              {" "}
              <a>For Cats</a>
            </li>
            <li>
              {" "}
              <a>For Small Pets</a>
            </li>
            <li>
              <a>Consult a Vet</a>
            </li>
            <li>
              <a>Dog Behaivour</a>
            </li>
            <li>
              <a>Pet Pharmacy</a>
            </li>
          </ul>
        </div>
        <div className="explore">
          <h3>EXPLORE</h3>
          <ul>
            <li>
              <a>Our Story</a>
            </li>
            <li>
              <a>FAQs</a>
            </li>
            <li>
              <a>Blog</a>
            </li>
            <li>
              <a>Contact Us</a>
            </li>
          </ul>
        </div>
        <div className="quickLinks">
          <h3>QUICK LINKS</h3>
          <ul>
            <li>
              <a>My Account</a>
            </li>
            <li>
              <a>Track My Order</a>
            </li>
            <li>
              <a>Refund policy</a>
            </li>
            <li>
              <a>Refund policy</a>
            </li>
            <li>
              <a>Privacy Policy</a>
            </li>
            {/* <li>
            <a>Terms of Use</a>
          </li> */}
          </ul>
        </div>
        <div className="followUs">
          <h3>FOLLOW US</h3>
          <ul>
            <li>
              <a>Facebook</a>
            </li>
            <li>
              <a>Instagram</a>
            </li>
            <li>
              <a>Twitter</a>
            </li>
          </ul>
        </div>
        <div className="getInTouch">
          <h3>GET IN TOUCH</h3>
          <ul>
            <li>
              <a>1800-5723-575</a>
            </li>
            <li>
              <a>support@supertails.com</a>
            </li>
          </ul>
        </div>
      </div>
    </div>
  );
};

export default Footer;
