import React from "react";
import Image from "next/image";
const page = () => {
    return (
        <div className="grid grid-cols-1 sm:grid-cols-2 h-screen w-full">
            <div className="hidden sm:block">
                <img
                    src={
                        "https://crc891.com/wp-content/uploads/2019/06/Universidad-Catolica-Costa-Rica1_Carrusel.jpg"
                    }
                    alt="Background Login Image"
                    className="w-full h-full object-cover"
                />
            </div>
            <div className="flex flex-col justify-center">
                <form
                    action=""
                    className="max-w-[400px] w-full mx-auto p-8 px-8"
                >
                    <h2 className="text-4xl font-semibold my-5">Ingresar</h2>
                    <div className="flex flex-col text-gray-700 py-2">
                        <label htmlFor="">
                            Identificacion del usuario soporte
                        </label>
                        <input
                            className="border border-gray-400 mt-2 p-2 focus:border-gray-600 focus:outline-none"
                            type="text"
                            required
                        />
                    </div>
                    <div className="flex flex-col text-gray-700 py-2">
                        <label htmlFor="">Contraseña</label>
                        <input
                            className="border border-gray-400 mt-2 p-2 focus:border-gray-600 focus:outline-none"
                            type="password"
                            required
                        />
                    </div>

                    <button className="transition text-white w-full my-5 py-5 bg-green-600 shadow-sm font-semibold hover:bg-green-700">
                        Ingresar
                    </button>
                </form>
            </div>
        </div>
    );
};

export default page;
