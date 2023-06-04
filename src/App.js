import 'fontsource-roboto';
import {BrowserRouter} from "react-router-dom";
import RouterConfig from "./navigation/routerConfig";

function App() {
  return (
  <BrowserRouter>
    <RouterConfig/>
  </BrowserRouter>);
}

export default App;
