import React from "react";

const now: Date = new Date();

const AppBar = () => {
    return (
        <header className="py-5 bg-[#0098bb]">
            <nav className="w-full flex flex-row justify-between items-center px-20">
                <img
                    src={
                        "https://ctpcalleblancos.ed.cr/wp-content/uploads/2020/08/130x130-min.png"
                    }
                    alt="Logo colegio"
                />
                <h1 className="text-2xl font-bold text-white">
                    Proceso Electoral {`${now.getFullYear()}`}
                </h1>
            </nav>
        </header>
    );
};

export default AppBar;
