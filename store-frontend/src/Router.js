import { Route, Routes } from "react-router-dom";
import Dashboard from "./dashboard/Dashboard";
import IndexCategory from "./components/Category/IndexCategory";
import CategoryForm from "./components/Category/CategoryForm";
import SubCategoryIndex from "./components/SubCategory/SubCategoryIndex";
import SubCategoryForm from "./components/SubCategory/SubCategoryForm";
import ProductIndex from "./components/Product/ProductIndex";
import ProductForm from "./components/Product/ProductForm";
import StockIndex from "./components/Stock/StockIndex";
import StockForm from "./components/Stock/StockForm";
import RequisitionIndex from "./components/Requisition/RequisitionIndex";
import RequisitionForm from "./components/Requisition/RequisitionForm";

function Router() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/products" element={<ProductIndex />} />
        <Route path="products/create" element={<ProductForm />} />
        <Route path="/categories" element={<IndexCategory />} />
        <Route path="categories/create" element={<CategoryForm />} />
        <Route path="/subcategories" element={<SubCategoryIndex />} />
        <Route path="subcategories/create" element={<SubCategoryForm />} />
        <Route path="/stocks" element={<StockIndex />} />
        <Route path="stocks/create" element={<StockForm />} />
        <Route path="/requisitions" element={<RequisitionIndex />} />
        <Route path="requisitions/create" element={<RequisitionForm />} />
      </Routes>
    </>
  );
}

export default Router;
