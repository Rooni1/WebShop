import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:44313/api';

axios.interceptors.response.use(async response => {
  return response;
}, (error) => {
  console.log(error);
  const {data, status, config} = error.response;
  switch (status) {
    case 400:
      if (typeof data === 'string') {
	console.log(data);
      }
      if (config.method === 'get' && data.errors.hasOwnProperty('id')) {
	//history.push('/not-found');
      }
      if (data.errors) {
	const modalStateErrors = [];
	for (const key in data.errors) {
	  if (data.errors[key]) {
	    modalStateErrors.push(data.errors[key]);
	  }
	  throw modalStateErrors.flat();
	}
      }
      console.log('bad request');
      break;
    case 401:
      console.log('unauthorized');
      break;
    case 404:
      //history.push('/not-found');
      break;
    case 500:
      //store.commonStore.setServerError(data);
      //history.push('/server-error');
      break;
  }
  return Promise.reject(error);
})

function get (url) {
  return axios.get(url).then((response) => response.data);
}

function post(url, order) {
  axios.post(url, order);
}

function productList() {
  return get('/Product/GetAll');
}

function details(id) {
  return get(`/People/Get/${id}`);
}

function placeOrder(order) {
  post(`/Order/Create`, order);
}

const agent = {
  productList,
  placeOrder
}

export default agent;
