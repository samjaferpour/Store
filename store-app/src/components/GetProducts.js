import axios from 'axios';
import React, { Fragment, useEffect, useState } from 'react'

const GetProducts = () => {
    const [products, setProducts] = useState([]);
    const getAll = () => {
        try {
            const apiUrl = "https://localhost:7072/api/Product/GetAllProducts";
            axios.get(apiUrl)
                .then(response => {
                    setProducts(response.data.resultData);
                }
                );

        } catch (error) {
            alert('error');
        }
    }

    useEffect(() => {
        getAll();
    }, []);

    return (
        <Fragment>
            <h3>Get All Products</h3>
            <table className='table table-striped teble-bordered container'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Price</th>
                        <th>Description</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        products.map(item => {
                            return (
                                <tr key={item.id}>
                                    <td>{item.name}</td>
                                    <td>{item.price}</td>
                                    <td>{item.description}</td>
                                </tr>
                            )
                        })
                    }
                </tbody>
            </table>
        </Fragment>
    )
}

export default GetProducts