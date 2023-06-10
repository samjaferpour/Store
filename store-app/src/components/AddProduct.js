import React, { Fragment, useState } from 'react'
import axios from 'axios';

const AddProduct = () => {
    const [product, setProduct] = useState({
        name: '',
        price: '',
        description: ''
    });
    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const apiUrl = "https://localhost:7072/api/Product/AddProduct";
            const response = await axios.post(apiUrl, product);
            alert(response.data.resultData);
            console.log(response);
            setProduct({
                name: '',
                price: '',
                description: ''
            });
        } catch (error) {
            alert('error')
        }
    }
    const handleChange = (event) => {
        const { name, value } = event.target;
        setProduct(prevProduct => ({ ...prevProduct, [name]: value }));
    }
    return (
        <Fragment>
            <h3>Add Product</h3>
            <div className='row'>
                <form onSubmit={(event) => handleSubmit(event)} className='frorm-group col-md-6'>
                    
                    <label className='form-control'>
                        Name:
                        <input type='text' name='name' onChange={(event) => handleChange(event)} />
                    </label>
                    <label className='form-control'>
                        Price:
                        <input type='text' name='price' onChange={(event) => handleChange(event)} />
                    </label>
                    <label className='form-control'>
                        Description:
                        <input type='text' name='description' onChange={(event) => handleChange(event)} />
                    </label>
                    <button className='btn btn-success' type='submit'>Add New Product</button>
                </form>
            </div>
        </Fragment>
    )
}

export default AddProduct