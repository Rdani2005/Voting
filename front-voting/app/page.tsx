"use client";
import { GetSingleVoter } from "@/Services/GetAllUsers";
import { useEffect, useState } from "react";
import {
    VoterGlobalContextProvider,
    useVoterContext,
} from "./context/VoterStore";
import { redirect, useRouter } from "next/navigation";
import axios from "axios";

const now: Date = new Date();

export default function Home() {
    return (
        <main className="flex min-h-screen flex-col items-center justify-between px-24">
            <section>
                <div className="flex flex-row px-72 py-24 justify-between items-center">
                    <img
                        src={
                            "https://ctpcalleblancos.ed.cr/wp-content/uploads/2020/08/130x130-min.png"
                        }
                        alt="Logo colegio"
                    />
                    <h1 className="text-5xl text-black w-[60%] text-center">
                        Bienvenido al proceso Electoral {now.getFullYear()}
                    </h1>
                </div>
                <AdminForm />
            </section>
        </main>
    );
}

const LookVoter = (identification: String) => {
    return GetSingleVoter(identification)
        .then((data) => data)
        .catch((err) => {
            alert("Votante No encontrado en BD. Contacte al administrador.");
            return err;
        });
};

async function checkIfUserHasVoted(voterId: number): Promise<boolean> {
    try {
        const response = await axios.post(
            `http://localhost:5251/api/v1/voter/${voterId}/vote`
        );
        return response.status !== 200;
    } catch (error) {
        // Maneja los errores adecuadamente
        console.error("Error al verificar si el usuario ha votado:", error);
        throw error;
    }
}

const AdminForm = () => {
    const [identification, setIdentification] = useState<String>("");

    const { actualVoter, setActualVoter } = useVoterContext();
    const router = useRouter();
    useEffect(() => {
        if (actualVoter != null) {
            redirect("/voting");
        }
    }, []);

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        LookVoter(identification)
            .then(async (data) => {
                console.log("Desde aqui vamos bien!");
                const userHasVote = await checkIfUserHasVoted(data.id);
                if (!userHasVote) {
                    setActualVoter(data);
                    alert("Usuario Fue encontrado, y puede ejercer su voto.");
                    router.push("/voting");
                } else {
                    alert("Usuario Fue encontrado, pero ya ejercio su voto.");
                }
            })
            .catch((err) => {
                alert(
                    "Votante No encontrado en BD. Contacte al administrador."
                );
                return err;
            });
    };
    return (
        <div className="px-24">
            <form onSubmit={(e) => handleSubmit(e)}>
                <div className="shadow sm:rounded-md sm:overflow-hidden border-gray-600 items-center">
                    <div className="px-4 py-5 bg-white space-y-6 sm:p-6">
                        <div>
                            <label
                                htmlFor="about"
                                className="block text-sm font-medium text-gray-700"
                            >
                                Identificación Del Estudiante
                            </label>
                            <div className="mt-1">
                                <input
                                    type="text"
                                    className="py-2 px-7 border border-gray-700 outline-none focus:outline-none rounded-md"
                                    onChange={(e) =>
                                        setIdentification(e.target.value)
                                    }
                                />
                            </div>
                        </div>
                    </div>
                    <div className="px-4 py-3 bg-gray-50 text-right sm:px-6">
                        <button
                            type="submit"
                            className="inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
                        >
                            Ingresar
                        </button>
                    </div>
                </div>
            </form>
        </div>
    );
};
