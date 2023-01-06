import { React, useState, useEffect } from "react";
import { Bar,Line } from "react-chartjs-2";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  BarElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
} from 'chart.js';
import axios from "axios";
import NavigationBar from "../NavigationBar";
ChartJS.register(
  BarElement,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);

const Analytics = () => {
  const [regdate, setregdate] = useState([]);
  const [numusers, setnumusers] = useState([]);
  const data = {
    labels: regdate,

    datasets: [
      {
        label:'Number Of users Registeres per day',
        data: numusers,
        borderColor: '#868a86',
        backgroundColor: ['#9BD0F5','#81cf7e'],
      },
    ],
  };

  const options = {
    Plugins: {
      legend: {
        position: "top",
      },
      title: {
        display: true,
        text: 'Number Of users Registered per day',
      },
    },
    scales:{
      y:{
        grid:{
          display:false
        },
        min:0
        
      },
      x:{
        grid:{
          display:false
        }
        
      }
    }
  };

  const url = "https://localhost:44388/api/Admin/RegAnalytics";

  useEffect(() => {
    axios.get(url).then((res) => {
      console.log(res);
      setnumusers(res.data.num_users);
      setregdate(res.data.reg_date);
    });
  }, []);

  return (
    <>
    <NavigationBar/>
    <div
      className="container"
      style={{
        height:"50%" ,
        width: "65%",
        responsive: "true",
        maintainAspectRatio: "true",
        
        padding:"auto",
        margin:"10em",
        display:"block",
        justifyContent:'center'
      }}
    >
      <Bar data={data} options={options} />
    </div>
    <div
      className="container"
      style={{
        height:"50%" ,
        width: "65%",
        responsive: "true",
        maintainAspectRatio: "true",
        padding:"auto",
        margin:"10em",
        display:"block",
        justifyContent:'center'
      }}
    >
      <Line data={data} options={options} />
    </div>
    </>
  );
};

export default Analytics;
