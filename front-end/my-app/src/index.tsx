import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import LoginPage from "./Pages/LoginPage";
import RegistrationPage from "./Pages/RegistrationPage";
import HomePage from "./Pages/HomePage";
import TravelOfferPage from "./Pages/TravelOfferPage";
import "./reset.scss";
import AgenciesPage from "./Pages/AgenciesPage";
import AgencyFormPage from "./Pages/AgencyFormPage";

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);

root.render(
  <BrowserRouter>
    <React.StrictMode>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegistrationPage />} />
        <Route path="/travelOffer" element={<TravelOfferPage />} />
        <Route path="/agencies" element={<AgenciesPage />} />
        <Route path="/agencies/new" element={<AgencyFormPage />} />
      </Routes>
    </React.StrictMode>
  </BrowserRouter>
);
