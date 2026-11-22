
import { useEffect, useState } from 'react'
import './App.css'

function App() {
  const [products, setProducts] = useState([])

  const [product, setProduct] = useState({
    productName: '',
    description: '',
    price: '',
    stockQuantity: '',
    category: ''
  })

  const [showForm, setShowForm] = useState(false)
  const [editingId, setEditingId] = useState(null)

  useEffect(() => {
    loadProducts()
  }, [])

  // Get all products
  const loadProducts = () => {
    fetch('https://localhost:7108/api/Products')
      .then(response => response.json())
      .then(data => setProducts(data))
      .catch(error => console.log(error))
  }

  // Handle input changes
  const handleChange = (e) => {
    setProduct({
      ...product,
      [e.target.name]: e.target.value
    })
  }

  // Reset form
  const resetForm = () => {
    setProduct({
      productName: '',
      description: '',
      price: '',
      stockQuantity: '',
      category: ''
    })

    setEditingId(null)
    setShowForm(false)
  }

  // Add or Update Product
  const handleSubmit = async (e) => {
    e.preventDefault()

    const productData = {
      ...product,
      price: Number(product.price),
      stockQuantity: Number(product.stockQuantity)
    }

    const url = editingId
      ? `https://localhost:7108/api/Products/${editingId}`
      : 'https://localhost:7108/api/Products'

    const method = editingId ? 'PUT' : 'POST'

    try {
      const response = await fetch(url, {
        method: method,
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(productData)
      })

      if (response.ok) {
        alert(editingId
          ? 'Product updated successfully!'
          : 'Product added successfully!')

        resetForm()
        loadProducts()
      } else {
        const errorData = await response.text()
        console.log(errorData)
        alert('Failed to save product')
      }
    } catch (error) {
      console.log(error)
      alert('Something went wrong')
    }
  }

  // Select product for editing
  const handleEdit = (selectedProduct) => {
  alert('Edit button clicked!')

  setProduct({
    productName: selectedProduct.productName,
    description: selectedProduct.description,
    price: selectedProduct.price,
    stockQuantity: selectedProduct.stockQuantity,
    category: selectedProduct.category
  })

  setEditingId(selectedProduct.productId)
  setShowForm(true)
}

  return (
    <div className="container">

      <h1>E-Commerce Order Management</h1>

      <h2>Products</h2>

      <button onClick={() => {
        resetForm()
        setShowForm(true)
      }}>
        Add New Product
      </button>

      {showForm && (
        <form onSubmit={handleSubmit}>

          <input
            name="productName"
            placeholder="Product Name"
            value={product.productName}
            onChange={handleChange}
            required
          />

          <input
            name="description"
            placeholder="Description"
            value={product.description}
            onChange={handleChange}
            required
          />

          <input
            name="price"
            type="number"
            placeholder="Price"
            value={product.price}
            onChange={handleChange}
            required
          />

          <input
            name="stockQuantity"
            type="number"
            placeholder="Stock Quantity"
            value={product.stockQuantity}
            onChange={handleChange}
            required
          />

          <input
            name="category"
            placeholder="Category"
            value={product.category}
            onChange={handleChange}
            required
          />

          <button type="submit">
            {editingId ? 'Update Product' : 'Save Product'}
          </button>

          <button type="button" onClick={resetForm}>
            Cancel
          </button>

        </form>
      )}

      <div className="product-container">

        {products.map(product => (
          <div className="product-card" key={product.productId}>

            <h3>{product.productName}</h3>
            <p>{product.description}</p>
            <h3>₹{product.price}</h3>
            <p>Stock: {product.stockQuantity}</p>
            <p>Category: {product.category}</p>

            <button onClick={() => handleEdit(product)}>
              Edit Product
            </button>

          </div>
        ))}

      </div>

    </div>
  )
}

export default App
