import axios from "axios";

const api = axios.create({
  baseURL: "https://goglobeapi.azurewebsites.net/api",
});

export default api;
