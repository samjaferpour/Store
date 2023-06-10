import './App.css';
import AddProduct from './components/AddProduct';
import GetProducts from './components/GetProducts';
import PageHead from './costom-components/PageHead';

function App() {
  return (
    <div className="App">
      <PageHead title='Home' />
      <AddProduct />
      <GetProducts />
    </div>
  );
}

export default App;
