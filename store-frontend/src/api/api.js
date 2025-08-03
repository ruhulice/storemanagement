import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7203/api/",
});

export default api;
