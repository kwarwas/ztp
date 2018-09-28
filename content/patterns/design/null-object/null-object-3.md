## Null Object design pattern

    function tree_size(node) {
        return 1 + tree_size(node.left) + tree_size(node.right)
    }

https://en.wikipedia.org/wiki/Null_object_pattern