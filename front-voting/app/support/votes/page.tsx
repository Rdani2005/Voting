"use client";
import React, { useEffect, useState } from "react";
import { Bar } from "react-chartjs-2";
import axios from "axios";
import { ChartOptions } from "chart.js";

const now: Date = new Date();

interface ChartDataItem {
    politicalPartyName: string;
    voteAmount: number;
}

const page = () => {
    const [chartData, setChartData] = useState({
        labels: ["", "", ""],
        datasets: [
            {
                label: "",
                data: [0, 0, 0],
                backgroundColor: "rgba(75, 192, 192, 0.6)",
            },
        ],
    });

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await axios.get<ChartDataItem[]>("/api/data"); // Reemplaza '/api/data' con la URL correcta de tu API
            const data = response.data;

            const labels = data.map((item) => item.politicalPartyName);
            const voteAmounts = data.map((item) => item.voteAmount);

            setChartData({
                labels: labels,
                datasets: [
                    {
                        label: "Cantidad de votos",
                        data: voteAmounts,
                        backgroundColor: "rgba(75, 192, 192, 0.6)",
                    },
                ],
            });
        } catch (error) {
            console.error("Error al obtener los datos del gráfico:", error);
        }
    };

    const options: ChartOptions = {}; // Puedes configurar las opciones del gráfico según tus necesidades

    return (
        <div>
            <h2>Gráfico de barras</h2>
            <Bar data={chartData} options={options} />
        </div>
    );
};

export default page;
