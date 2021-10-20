import axios, { AxiosError, AxiosResponse } from 'axios';
//import { history } from '../..';
//import { ProductVm } from '../models/peopleVm';
//import { Person } from '../models/person';
//import { store } from '../stores/store';

const sleep = (delay) => {
  return new Promise((resolve) => {
    setTimeout(resolve, delay)
  })
}

axios.defaults.baseURL = 'https://localhost:44313/api';

axios.interceptors.response.use(async response => {
  //await sleep(1000);
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

//const responseBody =  (response) => response.data;

/**const promise = axios.get(url)

    // using .then, create a new promise which extracts the data
    const dataPromise = promise.then((response) => response.data)

    // return it
    return dataPromise
**/

function get (url) { 
    return axios.get(url).then((response) => response.data);
}
  //</T>/post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
  //</T></T>put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
  //</T>del: <T> (url: string) => axios.delete<T>(url).then(responseBody),
//}

function productList() {
  return get('/Product/GetAll');
}

function details(id) {
  return get(`/People/Get/${id}`);
}
  /**</PeopleVm>search: (name: string) => requests.get<PeopleVm>(`/People/Search/${name}`),
  details: (id: string) => requests.get<Person>(`/People/Get/${id}`),
  create: (person: Person) => axios.post<void>('/People/Create', person),
  update: (person: Person) => axios.put<void>(`/People/Update/${person.id}`, person),
  delete: (id: string) => axios.delete<void>(`/People/Delete/${id}`)</void>**/
//}



const agent = {
  productList/**,
  Countries,
  Cities,
  Languages**/
}

export default agent;