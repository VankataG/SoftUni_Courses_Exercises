const loadBtnEl = document.querySelector('#btnLoadPosts');
const viewBtnEl = document.querySelector('#btnViewPost');
const optionsSelectEl = document.querySelector('#posts');
const titleH1El = document.querySelector('#post-title');
const detailsPEl = document.querySelector('#post-body');
const commentsUlEl = document.querySelector('#post-comments');



function attachEvents() {
    loadBtnEl.addEventListener('click', handleLoadPosts)
    viewBtnEl.addEventListener('click', handleViewPost)
}

attachEvents();

async function handleLoadPosts(){
    optionsSelectEl.innerHTML = '';

    const postsResp = await fetch('http://localhost:3030/jsonstore/blog/posts');
    const postsInfo = await postsResp.json();

    const postsArr = Object.values(postsInfo);

    postsArr.forEach(post => {
        const newOption = document.createElement('option');
        newOption.value = post.id;
        newOption.textContent = post.title;

        optionsSelectEl.appendChild(newOption);
    })
}

async function handleViewPost(){
    commentsUlEl.innerHTML = '';

    const postsResp = await fetch('http://localhost:3030/jsonstore/blog/posts');
    const postsInfo = await postsResp.json();

    const postsArr = Object.values(postsInfo);

    const selectedPostId = optionsSelectEl.value;

    const selectedPostData = postsArr.find(p => p.id === selectedPostId);

    titleH1El.textContent = selectedPostData.title;
    detailsPEl.textContent = selectedPostData.body;

    const commentsResp = await fetch('http://localhost:3030/jsonstore/blog/comments');
    const commentsInfo = await commentsResp.json();

    const commentsArr = Object.values(commentsInfo);

    const postCommentsArr = commentsArr.filter(c => c.postId === selectedPostId)

    postCommentsArr.forEach(c => {
        const liEl = document.createElement('li');
        liEl.textContent = c.text;

        commentsUlEl.appendChild(liEl)
    })
    
}