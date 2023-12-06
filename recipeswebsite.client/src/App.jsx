import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [recipes, setRecipes] = useState();

    useEffect(() => {
        populateRecipes();
    }, []);

    const contents = recipes === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>id</th>
                    <th>name</th>
                    <th>description</th>
                   
                </tr>
            </thead>
            <tbody>
                {recipes.map(recipe =>
                    <tr key={recipe.id}>
                        <td>{recipe.id}</td>
                        <td>{recipe.recipeName}</td>
                        <td>{recipe.description}</td>
                        
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tabelLabel">Recipes</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );
    
    async function populateRecipes() {
        const response = await fetch('https://localhost:7132/api/Recipes');
        const data = await response.json();
        setRecipes(data);
    }
}

export default App;