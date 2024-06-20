let allClothesData = []; // To store all fetched data
let selectedSizes = [];  // To store selected sizes

// Fetch and display data
async function fetchData() {
    try {
        const response = await fetch('http://192.168.45.250:3000/api/CLothes/GetClothes');
        if (!response.ok) {
            throw new Error('Ошибка получения данных');
        }
        const data = await response.json();
        allClothesData = data; // Store data for later filtering
        displayClothes(data);
    } catch (error) {
        console.error(error);
    }
}

// Display clothes
function displayClothes(clothes) {
    const clothesContainer = document.querySelector('.main-content');
    clothesContainer.innerHTML = ''; // Clear previous content
    clothes.forEach(clothe => {
        if (clothe.clothe_type === 7) {
            const clotheDiv = document.createElement('a');
            clotheDiv.classList.add('container');
            clotheDiv.href = `../html/KartochkaTovara.html?id=${clothe.id}`;
            clotheDiv.onclick = () => {
                localStorage.setItem('selectedClothe', JSON.stringify(clothe));
            };
            clotheDiv.innerHTML = `
                <h1>${clothe.clothe_name}</h1>
                <h2>₽${clothe.clothe_price.toFixed(2)}</h2>
                <img src="../image/katalog/brukDjins/${clothe.clothe_image}" alt="${clothe.clothe_name}" onerror="this.onerror=null;this.src='../image/katalog/brukDjins/zagluha.png';">
                <div class="dimensions">
                    <h3>РАЗМЕРЫ</h3>
                    <div class="size-options">
                        ${parseSizes(clothe.clothe_size)}
                    </div>
                </div>
            `;
            clothesContainer.appendChild(clotheDiv);
        }
    });
}

// Parse sizes from string
function parseSizes(sizesString) {
    const sizes = sizesString.split(',').map(size => size.trim());
    return sizes.map(size => `<p>${size}</p>`).join('');
}

// Apply filters
function applyFilters() {
    console.log("Selected sizes: ", selectedSizes); // Debugging
    let filteredClothes = allClothesData;
    if (selectedSizes.length > 0) {
        filteredClothes = filteredClothes.filter(clothe => {
            const clotheSizes = clothe.clothe_size.split(',').map(size => size.trim());
            return selectedSizes.some(size => clotheSizes.includes(size));
        });
    }
    displayClothes(filteredClothes);
}

// Clear filters
function clearFilters() {
    selectedSizes = []; // Clear selected sizes
    document.querySelectorAll('.size-options-filter p').forEach(option => {
        option.classList.remove('selected'); // Remove 'selected' class from all filter options
    });
    displayClothes(allClothesData); // Display all clothes without filters
}

// Event listeners for size options
document.querySelectorAll('.size-options-filter p').forEach(option => {
    option.addEventListener('click', (e) => {
        const size = e.target.innerText;
        if (selectedSizes.includes(size)) {
            selectedSizes = selectedSizes.filter(s => s !== size);
            e.target.classList.remove('selected');
        } else {
            selectedSizes.push(size);
            e.target.classList.add('selected');
        }
        console.log("Updated selected sizes: ", selectedSizes); // Debugging
    });
});

// Event listener for apply button
document.querySelector('.apply-button').addEventListener('click', applyFilters);

// Event listener for clear button
document.querySelector('.clear-button').addEventListener('click', clearFilters);

// Event listener for filter link
document.getElementById('filter-link').addEventListener('click', (e) => {
    e.preventDefault();
    const filterForm = document.getElementById('filter-form');
    filterForm.classList.toggle('hidden');
});

// Fetch data on load
fetchData();