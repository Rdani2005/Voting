import "./globals.css";
import { Inter } from "next/font/google";

const inter = Inter({ subsets: ["latin"] });

const now: Date = new Date();

export const metadata = {
    title: `Votaciones ${now.getFullYear()}`,
    description: "Programa de Votaciones año 2023",
};

export default function RootLayout({
    children,
}: {
    children: React.ReactNode;
}) {
    return (
        <html lang="es">
            <body className={inter.className}>{children}</body>
        </html>
    );
}
