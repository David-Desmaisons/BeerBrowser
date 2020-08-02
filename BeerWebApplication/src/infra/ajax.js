import axios from "axios";

function getFullUrl(url) {
  const baseUrl = process.env.VUE_APP_BASE_URL;
  return `${baseUrl}api/${url}`;
}

async function get(url, params = null) {
  const completeUrl = getFullUrl(url);
  const response = await axios.get(completeUrl, { params });
  return response.data;
}

async function put(url, id, data) {
  const completeUrl = getFullUrl(url);
  const response = await axios.put(completeUrl, data, {
    withCredentials: true
  });
  return response.data;
}

async function post(url, data) {
  const completeUrl = getFullUrl(url);
  const response = await axios.post(completeUrl, data, {
    withCredentials: true,
    headers: { "Content-Type": "application/json" }
  });
  return response.data;
}

async function deleteAjax(url, data) {
  const completeUrl = getFullUrl(url);
  const response = await axios.delete(completeUrl, data, {
    withCredentials: true,
    headers: { "Content-Type": "application/json" }
  });
  return response.data;
}

export { get, put, post, deleteAjax };
