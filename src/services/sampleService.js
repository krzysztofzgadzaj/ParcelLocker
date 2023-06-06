import axios from 'axios';

export const GetDupa = () => {
  axios.get('https://localhost:7279/WeatherForecast').then(res => console.log(res));
};
