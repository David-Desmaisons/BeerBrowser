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

export { get };
